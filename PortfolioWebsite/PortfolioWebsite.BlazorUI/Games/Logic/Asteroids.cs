using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Games.Logic
{
    public class Asteroids : IGame
    {
        public List<GameEntity> GameEntities { get; set; }

        public async Task Initialize()
        {
            await Task.Run(() => GameEntities = new List<GameEntity>());

            GameEntities.Add(new GameEntity
            {
                ImagePath = "Images/IKMecha/IKMechaIcon.png",
                Width = 50,
                Height = 50
            });
        }

        public async Task Update(Dictionary<Keys, bool> input)
        {
            //await Task.Run(() => Console.WriteLine("Game running"));

            await Task.Delay(1);

            if(input[Keys.W])
                GameEntities[0].Position_Y++;
            else
                GameEntities[0].Position_Y = 0;

            //Console.WriteLine("Pos y: " + GameEntities[0].Position_Y);
        }
    }
}


/*
 
 OLD ASTEROIDS COMPONENT.RAZOR
 
@using PortfolioWebsite.BlazorUI.Games.Logic

<div style="background-color: red; width: 100%; height:100%; position: relative">
    @{
        foreach (var item in mylist)
        {
            <!--
                    <img src="xx" alt="img" width="x" height="x" style=""/>
            -->
        }
    }
</div>


<div style="background-color: red; width: 100%; height:100%; position: relative">
    <h3 class="white-text"
        style="position:absolute;
            left: @($"{position[0]}px");
            top: @($"{position[1]}px");">Asteroids</h3>
</div>




@code {


    private List<int> mylist;

    private readonly Logic.Asteroids gameLoop;

    public IGame GameLoop { get; set; } = new Logic.Asteroids();

    static int[] position = new int[2]; // 0 -> X, 1 -> Y
    static int[] velocity = new int[2]; // 0 -> X, 1 -> Y

    public async Task OnKeyDown(KeyboardEventArgs args)
    {
        if (args.Key == "d")
        {
            velocity[0] = 1;
        }

        if (args.Key == "a")
        {
            velocity[0] = -1;
        }
        if (args.Key == "w")
        {
            velocity[1] = -1;
        }

        if (args.Key == "s")
        {
            velocity[1] = 1;
        }

        if (args.Key == "q")
        {
            Console.WriteLine("pressed q");
            //await jsRuntime.InvokeVoidAsync("triggerPause");
        }

        await Task.Delay(1);
    }

    public async Task OnKeyUp(KeyboardEventArgs args)
    {
        if (args.Key == "d")
        {
            if (velocity[0] == 1)
                velocity[0] = 0;
        }

        if (args.Key == "a")
        {
            if (velocity[0] == -1)
                velocity[0] = 0;
        }
        if (args.Key == "w")
        {
            if (velocity[1] == -1)
                velocity[1] = 0;
        }

        if (args.Key == "s")
        {
            if (velocity[1] == 1)
                velocity[1] = 0;
        }

        await Task.Delay(1);
    }

}
 
 */
