namespace ShareIt.DiscussionCtx.Domain
{
    public abstract class Identity
    {
        public static implicit operator string(Identity id)
        {
            return id.ToString();
        }

        public override abstract string ToString();
    }
}