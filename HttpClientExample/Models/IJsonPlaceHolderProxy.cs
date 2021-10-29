using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExample.Models
{
    public interface IJsonPlaceHolderProxy
    {
        Task<List<Post>> GetPosts();
        Task<List<Comment>> GetComments();
    }
}
