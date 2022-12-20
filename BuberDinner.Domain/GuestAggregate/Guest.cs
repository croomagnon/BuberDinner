using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate;

internal sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();

    private readonly List<DinnerId> _pastDinnerIds = new();

    private readonly List<DinnerId> _pendingDinnerIds = new();

    private readonly List<BillId> _billIds = new();

    private readonly List<MenuReviewId> _menuReviewIds = new();

    private readonly List<Rating> _ratings = new();

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public string ProfileImage { get; }

    public decimal AverageRating { get; }

    public UserId UserId { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
