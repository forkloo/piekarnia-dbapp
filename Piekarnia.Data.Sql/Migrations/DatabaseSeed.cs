using Piekarnia.Data.Sql.DAO;
using Piekarnia.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piekarnia.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly PiekarniaDbContext _context;
        public DatabaseSeed(PiekarniaDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // encje
            var clientList = BuildClientList();
            _context.Client.AddRange(clientList);
            _context.SaveChanges();

            var productList = BuildProductList();
            _context.Product.AddRange(productList);
            _context.SaveChanges();

            var sellerList = BuildSellerList();
            _context.Seller.AddRange(sellerList);
            _context.SaveChanges();

            var orderList = BuildOrderList(clientList);
            _context.Order.AddRange(orderList);
            _context.SaveChanges();

            // relacje
            var productOrderList = BuildProductOrderList(productList, orderList);
            _context.ProductOrder.AddRange(productOrderList);
            _context.SaveChanges();

            var sellerOrderList = BuildSellerOrderList(orderList, sellerList);
            _context.SellerOrder.AddRange(sellerOrderList);
            _context.SaveChanges();

        }

        private IEnumerable<DAO.Client> BuildClientList()
        {
            List<DAO.Client> clientList = new List<DAO.Client>();
            DAO.Client client = new DAO.Client()
            {
                ClientName = "Marcin",
                ClientSurname = "Najman",
                ClientStreet = "Pomarańczowa",
                ClientBuildingNumber = "4",
                ClientCity = "Konin",
                ClientMail = "marcinmajman@marcinnajman.pl"
            };
            clientList.Add(client);

            DAO.Client client2 = new DAO.Client()
            {
                ClientName = "Krzysztof",
                ClientSurname = "Kononowicz",
                ClientStreet = "Żadna",
                ClientBuildingNumber = "0",
                ClientCity = "Nieistnieje Dolne",
                ClientMail = "krzykononowicz@wp.pl"
            };
            clientList.Add(client2);

            for (int i = 3; i <= 20; i++)
            {
                DAO.Client client3 = new DAO.Client()
                {
                    ClientName = "Klient"+i.ToString(),
                    ClientSurname = "Klientowski",
                    ClientStreet = "Każda",
                    ClientBuildingNumber = i.ToString(),
                    ClientCity = "Inowrocław",
                    ClientMail = "mail@mail"+i.ToString()+".pl"
                };
                clientList.Add(client3);
            }

            return clientList;
        }

        private IEnumerable<Product> BuildProductList()
        {
            var productList = new List<Product>
            {
                new Product
                {
                    ProductName = "Kajzerka",
                    ProductPrice = 1.23M,
                    IsAvailable = true
                },
                new Product
                {
                    ProductName = "Chleb razowy",
                    ProductPrice = 7.99M,
                    IsAvailable = true
                },
                new Product
                {
                    ProductName = "Pączek z marmoladą",
                    ProductPrice = 2.25M,
                    IsAvailable = true
                },
                new Product
                {
                    ProductName = "Obważanek",
                    ProductPrice = 3.20M,
                    IsAvailable = true
                },
            };
            return productList;
        }

        private IEnumerable<Seller> BuildSellerList()
        {
            var sellerList = new List<Seller>
            {
                new Seller(){
                    SellerName = "Grzegorz Mietczyński",
                    SellerMail = "gmietcz@wp.pl",
                    SellerCity = "Grabie",
                    SellerStreet = "Prosta",
                    SellerBuildingNumber = "2a",
                    SellerPhone = 999999999,
                },
                new Seller(){
                    SellerName = "Anita Pochlebo",
                    SellerMail = "anita@pochlebo.pl",
                    SellerCity = "Katowice",
                    SellerStreet = "Katowicka",
                    SellerBuildingNumber = "22",
                    SellerPhone = 999999999,
                },
            };
            return sellerList;
        }

        private IEnumerable<Order> BuildOrderList(IEnumerable<DAO.Client> clientList){
            Random rand = new Random();
            List<Order> orderList = new List<Order>();
            foreach (DAO.Client client in clientList){
                for(int i = 0; i < 2; i++){
                    orderList.Add(new Order
                    {
                        ClientId = client.ClientId,
                        DeliveryType = (DeliveryType)rand.Next(0, 2),
                    });
                }
            }
            return orderList;
        }

        private IEnumerable<ProductOrder> BuildProductOrderList(
            IEnumerable<Product> productList, IEnumerable<Order> orderList)
        {
            Random rand = new Random();
            
            var productOrder = new List<ProductOrder>();
            foreach (Product product in productList)
            {
                productOrder.Add(new ProductOrder
                {
                    ProductId = product.ProductId,
                    OrderId = orderList.ElementAt<Order>(rand.Next(0, orderList.Count())).OrderId,
                    ProductQuantity = rand.Next(0, 10)
                });
            }
            
            return productOrder;
        }

        private IEnumerable<SellerOrder> BuildSellerOrderList(
            IEnumerable<Order> orderList, IEnumerable<Seller> sellerList)
        {
            Random rand = new Random();

            var sellerOrder = new List<SellerOrder>();
            foreach (Order order in orderList)
            {
                sellerOrder.Add(new SellerOrder
                {
                    OrderId = order.OrderId,
                    SellerId = sellerList.ElementAt<Seller>(rand.Next(0, sellerList.Count())).SellerId,
                });
            }

            return sellerOrder;
        }
    }

}
