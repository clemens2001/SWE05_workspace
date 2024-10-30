using PersonAdmin.BusinessLogic;
using PersonAdmin.Dal.Simple;

namespace PersonAdmin.Test
{
    [TestClass]
    public class PersonServiceTests
    {
        [TestMethod]
        public async Task UpdateWithInvalidIdWritesCorrectResult()
        {
            var dao = new SimplePersonDao();
            var writer = new StringWriter();
            var service = new PersonService(dao, writer);

            await service.TestUpdateAsync(int.MaxValue);

            Assert.AreEqual($"before update (id={int.MaxValue}): <null>\r\n", writer.ToString());
        }
    }
}