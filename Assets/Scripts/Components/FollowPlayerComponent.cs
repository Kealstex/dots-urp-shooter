using Unity.Entities;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct FollowPlayerComponent : IComponentData
    {
        public bool disabled;
    }
}