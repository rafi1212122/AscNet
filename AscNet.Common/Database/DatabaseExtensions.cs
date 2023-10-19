using System.Linq.Expressions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;

namespace AscNet.Common.Database
{
    public static class DatabaseExtensions
    {
        public static BsonClassMap<T> SetDictionaryRepresentation<T, TMember>(this BsonClassMap<T> classMap, Expression<Func<T, TMember>> memberLambda, DictionaryRepresentation representation)
        {
            var memberMap = classMap.GetMemberMap(memberLambda);
            var serializer = memberMap.GetSerializer();
            if (serializer is IDictionaryRepresentationConfigurable dictionaryRepresentationSerializer)
                serializer = dictionaryRepresentationSerializer.WithDictionaryRepresentation(representation);
            memberMap.SetSerializer(serializer);
            return classMap;
        }
    }
}
