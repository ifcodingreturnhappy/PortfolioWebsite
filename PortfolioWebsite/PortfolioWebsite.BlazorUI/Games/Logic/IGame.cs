using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Games.Logic
{
    public interface IGame
    {
        public List<GameEntity> GameEntities { get; set; }
        public Task Initialize();
        public Task Update(Dictionary<Keys,bool> input);
    }
}
