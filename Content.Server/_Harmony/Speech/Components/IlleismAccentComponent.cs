using Content.Server._Harmony.Speech.EntitySystems;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server._Harmony.Speech.Components;

[RegisterComponent]
[Access(typeof(IlleismAccentSystem))]
public sealed partial class IlleismAccentComponent : Component
{
    [DataField("toggleAction", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ToggleAction = "ActionToggleIlleism";

    [DataField("toggleActionEntity")]
    public EntityUid? ToggleActionEntity;

    [DataField]
    public EntityUid? SelfToggleActionEntity;

    [DataField]
    public int IlleismStateIndex = 0;

    [DataField]
    public List<string> IlleismStrings = [" ", "-"];
}
