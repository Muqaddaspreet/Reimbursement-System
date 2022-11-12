export class ReimbursementData {
    reimbursementID:number=0;
    date:Date=new Date('1990-01-01');
    reimbursementType:string='';
    requestedBy:string='';
    requestedValue:number=0;
    approvedValue:number=0;
    approvedBy:string='';
    currency:string='';
    receiptAttached:string='';
    receiptImageLink:string='';
    requestedPhase:string='To be processed';
    internalNotes:string='';
}
