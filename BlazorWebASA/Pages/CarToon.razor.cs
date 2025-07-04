using Microsoft.AspNetCore.Components;
using Web.Entitys;

namespace Web.Pages;

public class CarToon_razor : ComponentBase
{
    protected string searchTerm = string.Empty;
    private string _sortOption = "TitleAsc";

    protected string SortOption
    {
        get => _sortOption;
        set
        {
            if (_sortOption != value)
            {
                _sortOption = value;
                FilterAnime();
            }
        }
    }

    private readonly List<Anime> Anime =
    [
        new Anime
        {
            Title = "轻音少女",
            ImageUrl = "./images/动漫/轻音少女.png",
            Rating = 5f,
            Description = "只是觉得女孩子们之间真好啊",
            UserReview = "S+++++"
        },

        new Anime
        {
            Title = "请问你要来点兔子吗",
            ImageUrl = "./images/动漫/请问你要来点兔子吗.png",
            Rating = 5f,
            Description = "在充满咖啡香气的兔子咖啡馆里，少女们展开了一段温馨治愈的故事",
            UserReview = "S+++++"
        },

        new Anime
        {
            Title = "悠哉日常大王",
            ImageUrl = "./images/动漫/悠哉日常大王.png",
            Rating = 5f,
            Description = "描绘了乡村学校中少女们的悠闲日常，充满欢笑与温情",
            UserReview = "S+++++"
        },

        new Anime
        {
            Title = "珈百璃的坠落",
            ImageUrl = "./images/动漫/珈百璃的坠落.png",
            Rating = 5f,
            Description = "天使珈百璃来到人间后沉迷游戏，展开了一系列搞笑的故事。",
            UserReview = "S+++"
        },

        new Anime
        {
            Title = "登山少女",
            ImageUrl = "./images/动漫/向山进发.png",
            Rating = 4.8f,
            Description = "",
            UserReview = "A+"
        },

        new Anime
        {
            Title = "孤独摇滚",
            ImageUrl = "./images/动漫/孤独摇滚.png",
            Rating = 4.9f,
            Description = "社恐少女后藤一里组建乐队，在音乐中寻找自我的故事。",
            UserReview = "S+++"
        },

        new Anime
        {
            Title = "放学后的海堤日记",
            ImageUrl = "./images/动漫/放学后的海堤日记.png",
            Rating = 4.7f,
            Description = "钓鱼社团的日常",
            UserReview = "A+"
        },

        new Anime
        {
            Title = "打了300年的史莱姆，不知不觉就练到了满级",
            ImageUrl = "./images/动漫/史莱姆.png",
            Rating = 4.8f,
            Description = "",
            UserReview = "A+"
        },

        new Anime
        {
            Title = "女孩的钓鱼慢活",
            ImageUrl = "./images/动漫/女孩的钓鱼慢活.png",
            Rating = 4.6f,
            Description = "",
            UserReview = "A"
        },

        new Anime
        {
            Title = "黄金拼图",
            ImageUrl = "./images/动漫/黄金拼图.png",
            Rating = 5f,
            Description = "",
            UserReview = "S+++"
        },

        new Anime
        {
            Title = "街角魔族",
            ImageUrl = "./images/动漫/街角魔族.png",
            Rating = 4.6f,
            Description = "",
            UserReview = "A+"
        }
    ];

    protected List<Anime> FilteredAnimeList { get; set; } = new();
    
    protected override void OnInitialized()
    {
        FilteredAnimeList = Anime.ToList();
    }

    public void FilterAnime()
    {
        var query = Anime.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(a => 
                (a.Title != null && a.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
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
        FilteredAnimeList = Anime.ToList();
    }
   
}
