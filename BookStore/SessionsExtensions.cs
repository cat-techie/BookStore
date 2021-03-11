using BookStore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Text;

namespace BookStore
{
    public static class SessionsExtensions
    {
        private const string key = "Cart";

        public static void Set(this ISession session, Cart value)
        {
            if (value is null)
                return;
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream, Encoding.UTF8, true);
            writer.Write(value.OrderID);
            writer.Write(value.TotalCount);
            writer.Write(value.TotalPrice);

            session.Set(key, stream.ToArray());
        }

        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using var stream = new MemoryStream(buffer);
                using var reader = new BinaryReader(stream, Encoding.UTF8, true);
                var orderID = reader.ReadInt32();
                var totalCount = reader.ReadInt32();
                var totalPrice = reader.ReadDecimal();

                value = new Cart(orderID)
                {
                    TotalCount = totalCount,
                    TotalPrice = totalPrice,
                };

                return true;
            }

            value = null;
            return false;
        }
    }
}
