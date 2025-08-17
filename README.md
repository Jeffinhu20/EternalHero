# Eternal Hero – Alpha 0.1

Base jogável estilo auto-run + combate automático.

## Montar cena (resumo)
1. Crie um `Plane` (chão) e luz.
2. Player: Capsule + NavMeshAgent + `PlayerAgent` + `AutoCombatController` + `Health`. Tag: `Player`.
3. Enemy: Capsule + NavMeshAgent + `EnemyAI` + `Health`. Layer: `Enemy`. Salve como **Prefab**.
4. `Spawner`: aponte `enemyPrefab` (seu prefab) e `player` (objeto do Player).
5. HUD (`Canvas`): Slider (HP), Text (ouro), `HUDController` ligado no `Health` do Player.
6. Em *File → Build Settings* adicione a cena em **Scenes in Build**.

## Build local (Unity)
- *File → Build Settings → Android → Switch Platform* → **Build**.
- Recomendado: **IL2CPP + ARM64** (para Play Store). Para teste rápido: Mono + ARMv7.

## Dica
- Faça *Bake* do NavMesh (Window → AI → Navigation) se usar agentes.
