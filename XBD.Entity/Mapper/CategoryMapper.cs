using Swift.Net.Base;

namespace XBD.Entity.Mapper
{
    public class CategoryMapper : BaseMap<Category>
    {
        public override void Init()
        {
            ToTable("Category");
            HasKey(m => m.Id);
        }
    }
}
