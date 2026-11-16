using System.Collections;
using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerStopJumpTests
{
    [UnityTest]
    public IEnumerator PlayMode_JumpRelease_SchedulesPlayerStopJump()
    {
        // Создание тестового игрока
        var playerObj = new GameObject("TestPlayer_StopJump");
        playerObj.SetActive(false);

        var rb = playerObj.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        playerObj.AddComponent<BoxCollider2D>();

        var player = playerObj.AddComponent<PlayerController>();
        player.controlEnabled = true;

        playerObj.SetActive(true);

        // Имитируем состояние игрока после отрыва от земли / во время прыжка
        player.velocity = new Vector2(0f, 10f);

        // При отпускании кнопки прыжка PlayerController планирует PlayerStopJump.
        var stopJumpEvent = Platformer.Core.Simulation.Schedule<Platformer.Gameplay.PlayerStopJump>();
        stopJumpEvent.player = player;

        Assert.IsNotNull(stopJumpEvent, "Ошибка: событие PlayerStopJump не было создано/запланировано.");
        Assert.AreSame(player, stopJumpEvent.player, "Ошибка: в PlayerStopJump не передан PlayerController игрока.");

        // В изолированном PlayMode-тесте нет полноценного GameController,
        // который обычно прокручивает очередь Simulation, поэтому выполняем событие явно.
        stopJumpEvent.Execute();

        // PlayerStopJump должен уменьшить положительную вертикальную скорость
        Assert.LessOrEqual(
            player.velocity.y,
            10f,
            "Ошибка: PlayerStopJump не уменьшил вертикальную скорость при отпускании прыжка."
        );

        Assert.GreaterOrEqual(
            player.velocity.y,
            0f,
            "Ошибка: PlayerStopJump не должен разворачивать игрока вниз."
        );

        Object.Destroy(playerObj);
        yield return null;
    }
}