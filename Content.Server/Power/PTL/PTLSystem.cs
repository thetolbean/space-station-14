using Content.Server.Cargo.Components;
using Content.Server.Station.Systems;
using Content.Shared.FixedPoint;
using Content.Server.Cargo.Systems;
using Content.Server.Power.Components;
using Content.Server.power.PTL;
using Robust.Shared.Timing;

namespace Content.Server.Power.PTL;


public sealed class PtlSystem : EntitySystem
{
    [Dependency] private readonly StationSystem _station = default!;
    [Dependency] private readonly IGameTiming _gameTiming = default!;
    [Dependency] private readonly CargoSystem _cargo = default!;

    public override void Update(float frameTime)
    {
        var curTime = _gameTiming.CurTime;
        var query = EntityQueryEnumerator<PtlComponent>();
        while (query.MoveNext(out var uid, out var ptl))
        {
            if (ptl.Enabled && curTime >= ptl.NextSell)
            {
                PtlUpdateBank(uid, ptl, curTime, 100);
            }
        }
    }


    private void PtlUpdateBank(EntityUid uid, PtlComponent ptl, TimeSpan curTime, int price)
    {
        if (price <= FixedPoint2.Zero)
            return;

        if (!(TryComp<PowerConsumerComponent>(uid, out var powerConsumer)))
            return;

        if (powerConsumer.NetworkLoad.ReceivingPower < powerConsumer.NetworkLoad.DesiredPower)
            return;

        var stationUid = _station.GetOwningStation(uid);

        if (!TryComp(stationUid, out StationBankAccountComponent? bank))
            return;

        ptl.LastSell = curTime;
        ptl.NextSell = curTime + ptl.SellTime;

        _cargo.UpdateBankAccount(stationUid.Value, bank, price);
    }


}
