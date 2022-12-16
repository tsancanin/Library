using WebApplicationLibrary.DataConnection;
using WebApplicationLibrary.Entities;

namespace WebApplicationLibrary.Repository
{
    public class MemberRepository
    {
        private readonly LibraryContext _db;

        public MemberRepository(LibraryContext db)
        {
            _db = db;
        }

        public IEnumerable<Member> GetAll()
        {
            return _db.Members.ToList();   
        }

        public Member GetById(int id)
        {
            return _db.Members.SingleOrDefault(x => x.Id == id);
        }

        public void Update (Member member)
        {
            _db.Members.Update(member);
            _db.SaveChanges();
        }

        public void Create (Member member)
        {
            _db.Members.Add(member);
            _db.SaveChanges();
        }
        public void Delete (Member member)
        {
            _db.Members.Remove(member);
            _db.SaveChanges();
        }
    }
}
