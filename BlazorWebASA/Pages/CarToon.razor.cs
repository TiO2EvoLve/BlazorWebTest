using Microsoft.AspNetCore.Components;

namespace BlazorWebASA.Pages;

public class CarToon_razor : ComponentBase
{

    public string searchTerm = string.Empty;
    public string _sortOption = "TitleAsc";

    public string SortOption
    {
        get { return _sortOption; }
        set
        {
            if (_sortOption != value)
            {
                _sortOption = value;
                FilterAnime();
            }
        }
    }
    public List<Anime> originalAnimeList = new();
    public List<Anime> FilteredAnimeList { get; set; } = new();

    protected override void OnInitialized()
    {
        originalAnimeList = new List<Anime>
        {
            new Anime 
            { 
                Title = "轻音少女",
                ImageUrl = "./images/动漫/轻音少女.png",
                Rating = 5f,
                Description = "讲述了樱丘高中轻音部的故事，描绘了少女们追逐音乐梦想的温馨日常。",
                UserReview = "女孩子之间真是美好啊，音乐和友情的完美结合！"
            },
            new Anime 
            { 
                Title = "请问你要来点兔子吗",
                ImageUrl = "./images/动漫/请问你要来点兔子吗.png",
                Rating = 5f,
                Description = "在充满咖啡香气的兔子咖啡馆里，少女们展开了一段温馨治愈的故事。",
                UserReview = "每一集都让人感到温暖，是治愈系动画的经典之作。"
            },
            new Anime 
            { 
                Title = "悠哉日常大王",
                ImageUrl = "./images/动漫/悠哉日常大王.png",
                Rating = 5f,
                Description = "描绘了乡村学校中少女们的悠闲日常，充满欢笑与温情。",
                UserReview = "让人怀念起童年的美好时光，非常治愈。"
            },
            new Anime 
            { 
                Title = "珈百璃的坠落",
                ImageUrl = "./images/动漫/珈百璃的坠落.png",
                Rating = 5f,
                Description = "天使珈百璃来到人间后沉迷游戏，展开了一系列搞笑的故事。",
                UserReview = "反差萌太可爱了，笑点满满！"
            },
            new Anime 
            { 
                Title = "登山少女",
                ImageUrl = "./images/动漫/向山进发.png",
                Rating = 4.8f,
                Description = "少女们通过登山活动，体验自然之美，收获成长的故事。",
                UserReview = "看完之后特别想去爬山，风景太美了！"
            },
            new Anime 
            { 
                Title = "孤独摇滚",
                ImageUrl = "./images/动漫/孤独摇滚.png",
                Rating = 4.9f,
                Description = "社恐少女后藤一里组建乐队，在音乐中寻找自我的故事。",
                UserReview = "音乐和成长的故事，非常打动人心！"
            },
            new Anime 
            { 
                Title = "放学后的海堤日记",
                ImageUrl = "./images/动漫/放学后的海堤日记.png",
                Rating = 4.7f,
                Description = "钓鱼社团的日常",
                UserReview = "芳文社万岁!"
            }
        };
        
        FilteredAnimeList = originalAnimeList.ToList();
    }

    public void FilterAnime()
    {
        var query = originalAnimeList.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(a => 
                (a.Title != null && a.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (a.Description != null && a.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (a.UserReview != null && a.UserReview.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
        }
        
        query = SortOption switch
        {
            "TitleAsc" => query.OrderBy(a => a.Title),
            "TitleDesc" => query.OrderByDescending(a => a.Title),
            "RatingDesc" => query.OrderByDescending(a => a.Rating),
            "RatingAsc" => query.OrderBy(a => a.Rating),
            _ => query
        };
        
        FilteredAnimeList = query.ToList();
    }

    public void HandleSearchInput(ChangeEventArgs e)
    {
        searchTerm = e.Value?.ToString() ?? string.Empty;
    }

    public void ResetFilters()
    {
        searchTerm = string.Empty;
        SortOption = "TitleAsc";
        FilteredAnimeList = originalAnimeList.ToList();
    }

    public class Anime
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public float Rating { get; set; }
        public string? Description { get; set; }
        public string? UserReview { get; set; }
    }
}
