﻿namespace GraphQLCore.GraphiQLExample.Schema
{
    using System.Threading.Tasks;
    using Execution;
    using Models;
    using Type;

    public class GraphQLDroidObject : GraphQLObjectType<Droid>
    {
        public GraphQLDroidObject()
                : base("Droid", "A character in the Star Wars Trilogy")
        {
            this.Field("id", e => e.Id).WithDescription("The id of the droid.");
            this.Field("name", e => e.Name).WithDescription("The name of the droid.");
            this.Field("friends", e => e.Friends).WithDescription("The friends of the droid, or an empty list if they have none.");
            this.Field("appearsIn", e => e.AppearsIn).WithDescription("Which movies they appear in.");
            this.Field("primaryFunction", e => e.PrimaryFunction).WithDescription("The primary function of the droid.");
            this.Field("nameWithDelay", (IContext<Droid> ctx, int delay) => this.GetDelayedName(ctx.Instance, delay));

        }

        private async Task<string> GetDelayedName(Droid droid, int delay)
        {
            await Task.Delay(delay);
            return droid.Name;
        }
    }
}