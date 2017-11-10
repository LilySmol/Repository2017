using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Post
    {
        public int postID;
        public string postName;

        public Post()
        { }

        public Post(int id, string postName)
        {
            postID = id;
            this.postName = postName;
        }

        public int findPostId(string postN, List<Post> list) //найти id должности по наименованию
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].postName == postN)
                {
                    return list[i].postID;
                }
            }
            return -1;
        }

        public string findPostName(int postId, List<Post> list) //найти наименование по id
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].postID == postId)
                {
                    return list[i].postName;
                }
            }
            return "";
        }
    }
}
