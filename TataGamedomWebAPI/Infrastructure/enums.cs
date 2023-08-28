namespace TataGamedomWebAPI.Infrastructure
{
    enum Vote
    {
        Up = 1,
        Down = 0,
    }

    enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        ReturnProcessing = 3,
        Completed = 4,
    }

    enum ShipmentStatus
    {
        PreparingStock = 1,
        Shipped = 2,
        ArrivedNotPickedUp = 3,
        Delivered = 4,
        Returning = 5,
        PartiallyReturned = 6,
        FullyReturned = 7
    }

    enum PaymentStatus
    {
        Unpaid = 1,
        Paid = 2,
        NotRefunded = 3,
        PartiallyRefunded = 4,
        FullyRefunded = 5
    }

    enum DiscountType
    {
        PercentDiscount = 1,
        DirectDiscount = 2
    }

    enum LogisticsMethod
    {
        UNIMARTOnDelivery = 1,
        UNIMARTPurePickup = 2,
        FAMIPayOnDelivery = 3,
        FAMIPurePickup = 4,
        BlackCatOnDelivery = 5,
        BlackCatPurePickup = 6
    }
}
