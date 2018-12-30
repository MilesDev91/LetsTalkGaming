using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace TalkGaming.Controllers
{
    public static class GetContext
    {
        public static ObjectContext GetObjectContext(this IEntityWithRelationships entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var relationshipManager = entity.RelationshipManager;

            var relatedEnd = relationshipManager.GetAllRelatedEnds()
                                                .FirstOrDefault();

            if (relatedEnd == null)
                throw new Exception("No relationships found");

            var query = relatedEnd.CreateSourceQuery() as ObjectQuery;

            if (query == null)
                throw new Exception("The Entity is Detached");

            return query.Context;
        }
    }
}