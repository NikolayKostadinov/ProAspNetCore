using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Services
{
    public class CartFactory : ICartFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            ISession? session = this.httpContextAccessor.HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
    }
}
