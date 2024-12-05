namespace Content.Server.Power.PTL;


public sealed class PtlSystem : EntitySystem
{
    // Function from file CargoSystem.Orders.cs
    /* This function updates the station Bank Account, which we will need
    private void OnInteractUsing(EntityUid uid, CargoOrderConsoleComponent component, ref InteractUsingEvent args)
    {
        if (!HasComp<CashComponent>(args.Used))
            return;

        var price = _pricing.GetPrice(args.Used);

        if (price == 0)
            return;

        var stationUid = _station.GetOwningStation(args.Used);

        if (!TryComp(stationUid, out StationBankAccountComponent? bank))
            return;

        UpdateBankAccount(stationUid.Value, bank, (int) price);
        QueueDel(args.Used);
    } */
}
