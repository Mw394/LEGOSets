using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DTO.Model;
using DataAccess.Model;

namespace DataAccess.DBContext
{
    internal class LEGOInitializer : DropCreateDatabaseAlways<LEGODBContext>
    {

        protected override void Seed(LEGODBContext context)
        {
            var brick2x4White = new LEGOBrick("2x4 brick", 3001, Color.White);
            var brick2x2White = new LEGOBrick("2x2 brick", 3002, Color.White);
            var brick1x4White = new LEGOBrick("1x4 brick", 3003, Color.White);
            var brick1x2White = new LEGOBrick("1x2 brick", 3004, Color.White);
            var brick2x4Red = new LEGOBrick("2x4 brick", 3001, Color.Red);
            var brick2x2Red = new LEGOBrick("2x2 brick", 3002, Color.Red);
            var brick1x4Red = new LEGOBrick("1x4 brick", 3003, Color.Red);
            var brick1x2Red = new LEGOBrick("1x2 brick", 3004, Color.Red);
            var brick2x4Blue = new LEGOBrick("2x4 brick", 3001, Color.Blue);
            var brick2x2Blue = new LEGOBrick("2x2 brick", 3002, Color.Blue);
            var brick1x4Blue = new LEGOBrick("1x4 brick", 3003, Color.Blue);
            var brick1x2Blue = new LEGOBrick("1x2 brick", 3004, Color.Blue);
            var tire = new LEGOBrick("Tire Ø1", 59847, Color.Black);
            context.LEGOBricks.Add(brick2x4White);
            context.LEGOBricks.Add(brick2x2White);
            context.LEGOBricks.Add(brick1x4White);
            context.LEGOBricks.Add(brick1x2White);
            context.LEGOBricks.Add(brick2x4Red);
            context.LEGOBricks.Add(brick2x2Red);
            context.LEGOBricks.Add(brick1x4Red);
            context.LEGOBricks.Add(brick1x2Red);
            context.LEGOBricks.Add(brick2x4Blue);
            context.LEGOBricks.Add(brick2x2Blue);
            context.LEGOBricks.Add(brick1x4Blue);
            context.LEGOBricks.Add(brick1x2Blue);
            context.LEGOBricks.Add(tire);

            var LEGOset1 = new LEGOSet("Firetruck", "001", false, true);
            context.LEGOSets.Add(LEGOset1);
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick2x4White, 10));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick2x2White, 5));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick1x4White, 6));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick1x2White, 2));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick2x4Red, 10));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick2x2Red, 5));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick1x4Red, 8));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, brick1x2Red, 2));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset1, tire, 4));

            var LEGOset2 = new LEGOSet("Policecar", "002", false, true);
            context.LEGOSets.Add(LEGOset2);
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick2x4White, 8));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick2x2White, 4));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick1x4White, 3));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick1x2White, 2));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick2x4Blue, 8));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick2x2Blue, 6));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick1x4Blue, 4));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, brick1x2Blue, 4));
            context.SetBrickLinks.Add(new SetBrickLink(LEGOset2, tire, 4));
 

            context.SaveChanges();
        }

    }
}