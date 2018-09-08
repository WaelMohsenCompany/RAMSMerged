namespace MOL.EFDAL
{
    interface IAuditable
    {
        long CurrentUserID { get; set; }

        // Alternative : Table Name.
        string DBTableName { get; }

        /// <summary>
        /// Audit works by copying Database fields from table X into [MOL_AuditTrails] {OldValue, NewValue}.  
        /// ExtraField is a field that do NOT exist in table X, however we need to make an audit for it.
        /// For example Account Manager can be added by a user that is NOT stored anywhere in out database.  This is a business requiremet.
        /// So we add that user into IAuditable.ExtraFields.
        /// </summary>
        AuditExtraFieldCollection ExtraFields { get; }      
    }
}
