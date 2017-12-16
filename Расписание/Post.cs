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
    }
}
