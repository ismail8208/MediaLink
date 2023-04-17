namespace MediaLink.Application.Posts.Queries.GetPost;
public class PostDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? VideoURL { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
    public int UserId { get; set; }
}
