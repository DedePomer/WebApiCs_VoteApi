namespace Data.Model.Entity;

public class VotesEntity
{
    public Guid VoteId { get; init; } = Guid.NewGuid();
    public required Guid CandidateId { get; init; }
    public CandidatesEntity? Candidate { get; set; }
}