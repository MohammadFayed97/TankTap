namespace TankTap.Admistration.Application.Constants
{
	public static class MessagesAr
	{
		#region web
		public const string DataIncorrect = "بيانات التسجيل خاطئة !";
		public const string EmployeeNumberDuplication = "الرقم الوظيفي مكرر!";
		public const string StationCodeIsExist = "كود المحطة موجود بالفعل";
		public const string StationERDCodeIsExist = "ERD كود موجود بالفعل ";
		public const string AddStationSuccess = "تم اضافة المحطة بنجاح";
		public const string AddClientSuccess = "تم اضافة العملاء بنجاح";
		public const string AddStationFail = "لم يتم اضافة المحطة";
		public const string ProductNotFount = "الرقم التعريفي للمنتج غير موجود";
		public const string TankCodeIsExist = "كود الخزان موجود بالفعل";
		public const string PumpCodeIsExist = "كود الطرمبة موجود بالفعل";
		public const string PumpERDCodeIsExist = "ERD كود للطرمبة موجود بالفعل";
		public const string IPIsExist = "POS يجب ألا تتكرر بيانات ال ";
		public const string EmpolyeeIsExist = "البيانات موجودة بالفعل";
		public const string RoleNumberNotExist = "رقم الدور الوظيفي غير موجود";
		public const string EmployeeNumber = "الرقم الوظيفي {0} موجود بالفعل ";
		public const string DateFormat = "تنسيق التاريخ  {0}  غير صالح ";
		public const string EmailFormat = " البريد الالكتروني {0} غير صالح ";
		public const string EmailDuplication = " البريد الالكتروني موجود بالفعل ";
		public const string RoleNumber = " رقم الدور الوظيفي {0} غير صالح ";
		public const string UploadExcelSheetDone = " تم ادخال بيانات الموظفين بنجاح ";
		public const string PhoneDuplication = " رقم الهاتف {0} مسجل مكرر";
		public const string SuccessMessage = "إكتملت العملية بنجاح";
		public const string FailureMessage = "فشلت العملية";
		public const string ClientNameIsExist = "اسم العميل {0} موجود بالفعل";
		public const string ClientNameNotValid = "لا يمكن أن يكون الاسم خاليًا أو يتكون من مسافات فقط";
		public const string BalanceNameNotValid = "لا يمكن أن يكون الرصيد خاليًا أو يتكون من مسافات فقط";
		public const string AddressNotValid = "لا يمكن أن يكون العنوان خاليًا أو يتكون من مسافات فقط";
		public const string BuildingNumberNotValid = "لا يمكن أن يكون رقم المبنى خاليًا أو يتكون من مسافات فقط";
		public const string StreetNotValid = "لا يمكن أن يكون اسم الشارع خاليًا أو يتكون من مسافات فقط";
		public const string RegionNotValid = "لا يمكن أن يكون المنطقة خاليًا أو يتكون من مسافات فقط";
		public const string CityNotValid = "لا يمكن أن يكون المدينة خاليًا أو يتكون من مسافات فقط";
		public const string ZipCodeNotValid = "لا يمكن أن يكون الرقم البريدي خاليًا أو يتكون من مسافات فقط";
		public const string CompanyNameNotValid = "لا يمكن أن يكون إسم الشركة خاليًا أو يتكون من مسافات فقط";
		public const string VATNumberNotValid = "لا يمكن أن يكون VAT NUMBER خاليًا أو يتكون من مسافات فقط";
		public const string CommercialNumberNotValid = "لا يمكن أن يكون الرقم التجاري خاليًا أو يتكون من مسافات فقط";
		public const string BalanceNotValid = "يجب ان يكون الرصيد {0} رقم فقط ";
		public const string CommercialNumberExist = "الرقم التجاري {0} موجود بالفعل ";


		#endregion

		#region mobile
		public const string EmployeeNumberNotFound = "الرقم الوظيفي غير موجود!";
		public const string CustomerBalanceNotEnough = "رصيد العميل غير كافي!";
		public const string NeedToResetPassord = "برجاء اعادة تعيين كلمة المرور الخاصة بك ";
		public const string PasswordsNotMatch = "كلمة المرور غير متطابقة";
		public const string CredentialUpdated = "تم تحديث بيانات الاعتماد بنجاح";
		public const string MaxFailedAccessAttempts = "عفوا لقد تجاوزت العدد المسموح به لتسجيل الدخول الخاطئ";
		public const string RemainFailedAccessAttempts = " عدد المحاولات المتبقية لتسجيل الدخول هي ";
		public const string InvoicePriceOver = "سعر الفاتورة تجاوز الحد الأقصى المسموح به";
		public const string EmailNotFound = "البريد الالكتروني غير صحيح";
		public const string OTPSent = "تم إرسال كلمة المرور لمرة واحدة (OTP) بنجاح.";
		public const string OTPSentError = "حدث خطأ أثناء إرسال كلمة المرور لمرة واحدة (OTP).";
		public const string OTPInvalid = "رمز التحقق غير صالح أو انتهت صلاحيته.";
		public const string AndoidIdNotFound = "هذا الجهاز غير مسجل";
		public const string PasswordSubject = "كلمة مرورك الجديدة في انتظارك!";



		#endregion
	}
	public static class MessagesEn
	{
		#region web
		public const string SuccessMessage = "Completed Successfully";
		public const string FailureMessage = "Operation Failed!";
		#endregion

		#region mobile
		public const string EmployeeNumberNotFound = "Employee number not found!";
		public const string DataIncorrect = "Login credntials are not correct!";
		public const string CustomerBalanceNotEnough = "Customer balance not enough!";
		public const string NeedToResetPassord = "Please reset your password";
		public const string PasswordsNotMatch = "Password mismatch";
		public const string CredentialUpdated = "Credentials Updated successfully";
		public const string MaxFailedAccessAttempts = "Sorry, you have exceeded the wrong login limit";
		public const string RemainFailedAccessAttempts = "Number of login attempts remaining ";
		public const string InvoicePriceOver = "The invoice price exceeded the maximum allowed price.";
		public const string EmailNotFound = "Email is incorrect ";
		public const string OTPSent = "OTP sent successfully.";
		public const string OTPSentError = "An error occurred while sending OTP.";
		public const string OTPInvalid = "The OTP is invalid or has expired.";
		public const string AndoidIdNotFound = "This device is not registered";
		public const string PasswordSubject = "Your New Password Awaits!";


		#endregion
	}
	public static class MessagesUr
	{
		#region web

		#endregion

		#region mobile
		public const string EmployeeNumberNotFound = "ملازمت کا نمبر موجود نہیں ہے۔!";
		public const string DataIncorrect = "رجسٹریشن کا ڈیٹا غلط ہے۔ !";
		public const string CustomerBalanceNotEnough = "صارفین کا توازن ناکافی!";
		public const string NeedToResetPassord = "براہ مہربانی، اپنا پاس ورڈ دوبارہ سیٹ کریں";
		public const string PasswordsNotMatch = "پاس ورڈ مماثل نہیں ہے۔";
		public const string CredentialUpdated = "اسناد کامیابی کے ساتھ اپ ڈیٹ ہو گئیں۔";
		public const string MaxFailedAccessAttempts = "معذرت، آپ غلط لاگ ان کی حد سے تجاوز کر گئے ہیں۔";
		public const string RemainFailedAccessAttempts = "لاگ ان کی باقی کوششوں کی تعداد";
		public const string InvoicePriceOver = "انوائس کی قیمت زیادہ سے زیادہ اجازت سے زیادہ ہے۔";
		public const string EmailNotFound = "ای میل غلط ہے۔";
		public const string OTPSent = "OTP کامیابی سے بھیج دیا گیا۔";
		public const string OTPSentError = "OTP بھیجتے وقت ایک خرابی پیش آگئی۔";
		public const string OTPInvalid = "OTP غلط ہے یا اس کی میعاد ختم ہو چکی ہے۔";
		public const string AndoidIdNotFound = "یہ آلہ رجسٹرڈ نہیں ہے۔";
		public const string PasswordSubject = "آپ کا نیا پاس ورڈ منتظر ہے!";

		#endregion
	}
	public static class MessagesBen
	{
		#region web


		#endregion

		#region mobile
		public const string EmployeeNumberNotFound = "চাকরির নম্বর নেই!";
		public const string DataIncorrect = "নিবন্ধন তথ্য ভুল!";
		public const string CustomerBalanceNotEnough = "অপর্যাপ্ত গ্রাহক ব্যালেন্স!";
		public const string NeedToResetPassord = "আপনার পাসওয়ার্ড পুনরায় সেট করুন";
		public const string PasswordsNotMatch = "পাসওয়ার্ড মেলেনি";
		public const string CredentialUpdated = "শংসাপত্রগুলি সফলভাবে আপডেট হয়েছে৷";
		public const string MaxFailedAccessAttempts = "দুঃখিত, আপনি ভুল লগইন সীমা অতিক্রম করেছেন৷";
		public const string RemainFailedAccessAttempts = "বাকি লগইন প্রচেষ্টার সংখ্যা";
		public const string InvoicePriceOver = "চালানের মূল্য অনুমোদিত সর্বোচ্চ ছাড়িয়ে গেছে";
		public const string EmailNotFound = "ইমেল ভুল";
		public const string OTPSent = "OTP সফলভাবে পাঠানো হয়েছে।";
		public const string OTPSentError = "OTP পাঠানোর সময় একটি ত্রুটি ঘটেছে৷";
		public const string OTPInvalid = "OTP অবৈধ বা মেয়াদ শেষ হয়েছে।";
		public const string AndoidIdNotFound = "এই ডিভাইসটি নিবন্ধিত নয়৷";
		public const string PasswordSubject = "আপনার নতুন পাসওয়ার্ড অপেক্ষা করছে!";

		#endregion
	}

}
