using System;
using RetroCollector.Models;

public class NewLineItemAddedEventArgs : EventArgs {
    private TransactionLineItem lineItem;
    public TransactionLineItem LineItem {
        get => lineItem;
    }

    public NewLineItemAddedEventArgs(TransactionLineItem item) {
        lineItem = item;
    }
}