using Models.BaseModels.Diary;
using Services.Templates;

namespace Services.Interfaces.Diary
{
    public interface IDiaryOption : IGenericOperations_PK_GUID<DiaryOption>
    {
        public DiaryOption LoadDefaultValue();
    }
}
