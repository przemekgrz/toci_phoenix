﻿using Toci.ErrorsAndMessages.Managers;
using Toci.Utilities.Common.Exceptions;

namespace Toci.ErrorsAndMessages.Exceptions
{
    public class WebApiTociApplicationException : UiTociApplicationException
    {
        public WebApiTociApplicationException(string uiMessage, string errMessage, int errorCode, TociApplicationException innerException = null) : base(uiMessage, errMessage, errorCode, innerException)
        {
            LanguageManager = new BlindLanguageManager();
            Translator = new BlindTranslator();
        }
    }
}