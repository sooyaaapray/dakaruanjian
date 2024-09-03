
namespace ClockIn.Server.Start.Common
{
    public static class DynamicConverter
    {
        public static List<T> ConvertDynamicToGenericEntityList<T>(List<dynamic> dynamicList) where T : new()
        {
            List<T> entityList = new List<T>();

            foreach (var dynamicItem in dynamicList)
            {
                T entity = ConvertDynamicToGenericEntity(dynamicItem);
                entityList.Add(entity);
            }

            return entityList;
        }

        public static T ConvertDynamicToGenericEntity<T>(dynamic dynamicItem) where T : new()
        {
            T entity = new T();
            var entityType = typeof(T);

            foreach (var property in entityType.GetProperties())
            {
                if (dynamicItem.TryGetMember(property.Name, out object value))
                {
                    property.SetValue(entity, value);
                }
            }

            return entity;
        }
    }
}