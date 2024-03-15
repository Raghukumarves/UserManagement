using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Helpers
{
   public enum OutBoundEvents
    {
		ExamRequestAcknowledgementEvent = 2,
		ClarificationRequestEvent = 3,
		ContentionCancellationRequestedEvent = 10,
		ResultPackageAvailableEvent = 12,
		AppointmentScheduledEvent = 14,
		AppointmentCanceledEvent = 17,
		AppointmentCompletedEvent = 18,
		RescheduleRequestEvent = 19
    }

    public enum InboundEvents
	{
		ExamSchedulingRequestCreatedEvent = 1,
		ReworkExamSchedulingRequestCreatedEvent = 5,
		EditedRequestClarificationResponseEvent = 7,
		AddressChangeEvent = 8,
		ExamSchedulingRequestCancellationEvent = 9,
		ContentionCanceledEvent = 11,
		AppointmentCancelRequestEvent = 16,
		RescheduleRequestEvent = 19,
		NarrativeClarificationResponseEvent = 21,
		SpecialInstructionsEvent = 22,
		//EditedRequestClarificationResponseEvent = 23,
		ReworkEditedRequestClarificationResponseEvent = 25,
		RequestScopedFaultEvent = 51,
		ContentionScopedFaultEvent = 52,
		AppointmentScopedFaultEvent = 53,
		VeteranDocumentManifestEvent = 30
}
}