using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataGamedom.Models.Dtos.Games;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.Games;

namespace TataGamedom.Models.Interfaces
{
	public interface IGameRepository
	{
		IEnumerable<GameIndexDto> Search();
		Game GetGameById(int id);

		IEnumerable<GameClassificationGame> GetGameClassificationGames(int id);

		bool UpddateGame(GameEditDto dto);

		bool Create(GameCreateDto dto);

		Game GetGameByName(string chi, string eng);

		List<GameClassificationsCode> GetGameClassifications();
		bool EditGameCover(GameEditCoverImgDto dto);

		bool CreateBoard(Game game);

		bool UpdateClassification(GameEditVM game, int selectedGameClassification);

		bool CreateClassification(Game game, int gameClassificationId);

		BackendMember GetBackendMemberName(int? id);

		bool DeleteGameClassificationGames(int id);

		bool CreateProduct(Product product);
		bool CreateProductImg(ProductImage productImage);

		bool IsDuplicateChineseName(int gameId, string chiName);

		bool IsDuplicateEnglishName(int gameId, string engName);
	}
}
