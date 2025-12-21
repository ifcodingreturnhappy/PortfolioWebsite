namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class ContentInfoModel
    {
        public AnimationType AnimationType { get; set; }
        public ContentExcerptInfoModel Excerpt { get; set; }
        public ContentImageInfoModel Image { get; set; }
        public ContentTaggedCardInfoModel TaggedCard { get; set; }
        public ContentSourceCodeInfoModel SourceCode { get; set; }
        public ContentEmptyBlockInfoModel EmptyBlock { get; set; }
    }
}
