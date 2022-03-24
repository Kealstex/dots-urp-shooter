using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerComponent : IComponentData
{
   public float MovementSpeed;
   public float RotationSpeed;
}
