using Unity.Entities;
namespace Components
{
    [GenerateAuthoringComponent]
    public struct NavMeshAgentComponent : IComponentData
    {
        public Entity MoveEntity;
    }
}