using EventStore.ClientAPI;
using NUnit.Framework;
using ShareIt.EventStore;
using ShareIt.Infrastructure;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.Tests
{
    [TestFixture]
    public class EventStoreTest
    {
        [Test]
        public void Can_Save_Event_To_Event_Store()
        {
            //var bus = new Bus();
            //var getEventStoreRepository = new EventStoreRepository(bus);
            //getEventStoreRepository.Save();
        }
    }
}