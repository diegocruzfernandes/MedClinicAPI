using MedServer.Infra.Context;

namespace MedServer.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly DataContext _context;

        public Uow(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //Nothing... the EF dead de transaction; 
        }
    }
}
