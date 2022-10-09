using VendingMachine.Data;

namespace VendingMachineTest
{
    public class VendingMachineTest
    {
        [Fact]
        public void EndTransactionTest()
        {
            Dictionary<int, int>? actChange = new Dictionary<int, int>();
            VendingMachineService service = new VendingMachineService();
            service.MoneyPool = 38;
            Dictionary<int, int>? expChange = new Dictionary<int, int>()
            {
                {20, 1}, {10, 1}, {5, 1 }, {2, 1}, {1, 1}
            };

            actChange = service.EndTransaction();
            Assert.Equal(expChange, actChange);

        }
    }
}