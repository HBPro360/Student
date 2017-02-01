Public Class SearchCriteria

    Public Enum Type
        String_Starts_With = 0
        String_Ends_With = 1
        String_Contains = 2
        IntegerGT = 3
        IntegerLT = 4
        IntegerEQ = 5
        DateTme_Between = 6
        DateTme_LT = 7
        DateTme_GT = 8
        DateTme_EQ = 9
        [Boolean] = 10
        MoneyGT = 11
        MoneyLT = 12
        MoneyEQ = 13
    End Enum


End Class
