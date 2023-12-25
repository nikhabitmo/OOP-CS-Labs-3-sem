namespace ApplicationModels.Transaction;

public record Transaction(long TransactionId, long AccountId, string TransactionType, long Amount, DateTime DateTime);