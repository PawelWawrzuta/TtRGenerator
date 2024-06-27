using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtRGenerator.Models
{
    public class GameDetails
    {
        public int GameDetailsId { get; set; }

        public string GameName { get; set; }
        public GameDetails(int gameDetailsId, string gameName)
        {
            GameDetailsId = gameDetailsId;
            GameName = gameName;
        }
        public GameDetails()
        {

        }
    }
}
