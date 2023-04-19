using ProjetPFE.Contracts;
using ProjetPFE.Entities;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using ProjetPFE.Context;
using ProjetPFE.Dto;

namespace ProjetPFE.Repository
{

    public class OffreRepository : IOffreRepository
    {
        private readonly DapperContext _context;

        public OffreRepository(DapperContext context)
        {
            _context = context;
        }




        public async Task<IEnumerable<offre>> Getoffres()
        {
            var query = "SELECT * FROM offre";

            using (var connection = _context.CreateConnection())
            {
                var offres = await connection.QueryAsync<offre>(query);
                return offres.ToList();
            }
        }




        public async Task<offre> Getoffre(int offre_id)
        {
            var query = "SELECT * FROM offre WHERE offre_id = @offre_id";

            using (var connection = _context.CreateConnection())
            {
                var offre = await connection.QuerySingleOrDefaultAsync<offre>(query, new { offre_id });

                return offre;
            }
        }




        public async Task<offre> CreateOffre(OffreForCreationDto offre)
        {
            var query = "INSERT INTO offre (demande_id,  nb_poste, fonction, description, mission) " +
                "VALUES (@demande_id,  @nb_poste, @fonction, @description, @mission) SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("demande_id", offre.demande_id, DbType.Int32);
            parameters.Add("nb_poste", offre.nb_poste, DbType.Int32);
            parameters.Add("fonction", offre.fonction, DbType.String);
            parameters.Add("description", offre.description, DbType.String);
            parameters.Add("mission", offre.mission, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdoffre = new offre
                {
                    offre_id = id,
                    demande_id = offre.demande_id,
                    nb_poste = offre.nb_poste,
                    fonction = offre.fonction,
                    description = offre.description,
                    mission = offre.mission,


                };
                return createdoffre;
            }
        }



        public async Task UpdateOffre(int offre_id, OffreForUpdateDto offre)
        {
            var query = "UPDATE offre SET demande_id = @demande_id,  nb_poste = @nb_poste, fonction = @fonction, description = @description, " +
                "mission = @mission WHERE offre_id = @offre_id";

            var parameters = new DynamicParameters();
            parameters.Add("demande_id", offre.demande_id, DbType.Int32);
            parameters.Add("offre_id", offre_id, DbType.Int32);
            parameters.Add("nb_poste", offre.nb_poste, DbType.Int32);
            parameters.Add("fonction", offre.fonction, DbType.String);
            parameters.Add("description", offre.description, DbType.String);
            parameters.Add("mission", offre.mission, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }




        public async Task DeleteOffre(int offre_id)
        {
            var query = "DELETE FROM offre WHERE offre_id = @offre_id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { offre_id });
            }
        }



        //public async Task<IEnumerable<offre>> SearchOffreAsync(string search)
        //{
        //    return await _db.offre.OrderByDescending(x => x.offre_id).Include((x.SubCategory))
        //    .where(x => x.mission.ToLower().Contains(search.ToLower()) || x.SubCategory.SubCategoryName.ToLower().Contains(search.ToLower()))
        //    .ToListAsync();
        //}



        public async Task<IEnumerable<offre>> SearchOffreAsync(string search)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = @"
            SELECT * FROM offre
            WHERE LOWER(mission) LIKE '%' + @search + '%'
            OR LOWER(description) LIKE '%' + @search + '%'
            OR LOWER(fonction) LIKE '%' + @search + '%'
            ORDER BY offre_id DESC;
        ";

                var result = await connection.QueryAsync<offre>(
                    sql,
                    new { search = search.ToLower() });

                return result;
            }
        }






    }

}
