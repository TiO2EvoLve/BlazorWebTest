using Microsoft.AspNetCore.Components;
using Tommy;
using Web.Entitys;

namespace Web.Pages;

public class CarToon_razor : ComponentBase
{
    protected string searchTerm = string.Empty; //搜索内容
    private string _sortOption = "TitleAsc"; //默认排序选项

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

    [Inject] private HttpClient Http { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var tomlContent = await Http.GetStringAsync("data/cartoon.toml");
        using (var reader = new StringReader(tomlContent))
        {
            var table = TOML.Parse(reader);
            TomlArray animes = table["anime"] as TomlArray;

            foreach (TomlTable animeEntry in animes)
            {
                var anime = new Anime
                {
                    Title = animeEntry["Title"],
                    ImageUrl = animeEntry["ImageUrl"],
                    Rating = (float)(double)animeEntry["Rating"],
                    Description = animeEntry["Description"],
                    UserReview = animeEntry["UserReview"]
                };
                animeList.Add(anime);
                FilteredAnimeList = animeList.ToList();
            }
        }
    }

    private readonly List<Anime> animeList = new();
    protected List<Anime> FilteredAnimeList { get; set; } = new();

    protected override void OnInitialized()
    {
        FilteredAnimeList = animeList.ToList();
    }

    public void FilterAnime()
    {
        var query = animeList.AsQueryable();

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
        FilteredAnimeList = animeList.ToList();
    }
}