#if __IOS__ || MACCATALYST
using PlatformView = zoft.MauiExtensions.Controls.Platform.IOSAutoCompleteEntry;
#elif ANDROID
using PlatformView = zoft.MauiExtensions.Controls.Platform.AndroidAutoCompleteEntry;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.AutoSuggestBox;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.MauiSearchBar;
#else
using PlatformView = System.Object;
#endif
using Microsoft.Maui.Handlers;

namespace zoft.MauiExtensions.Controls.Handlers
{
	/// <summary>
	/// Handler implementation of the <see cref="AutoCompleteEntry"/>
	/// </summary>
	public partial class AutoCompleteEntryHandler : IAutoCompleteEntryHandler
	{
		/// <summary>
		/// Property mapper dictionary
		/// </summary>
		public static IPropertyMapper<AutoCompleteEntry, IAutoCompleteEntryHandler> Mapper =
			new PropertyMapper<AutoCompleteEntry, IAutoCompleteEntryHandler>(ViewMapper)
			{
#if __IOS__
				[nameof(IEntry.IsEnabled)] = MapIsEnabled,
#endif
                [nameof(IEntry.Background)] = MapBackground,
				[nameof(IEntry.CharacterSpacing)] = MapCharacterSpacing,
				[nameof(IEntry.Font)] = MapFont,
				[nameof(ITextAlignment.HorizontalTextAlignment)] = MapHorizontalTextAlignment,
				[nameof(ITextAlignment.VerticalTextAlignment)] = MapVerticalTextAlignment,
				[nameof(IEntry.IsReadOnly)] = MapIsReadOnly,
				[nameof(IEntry.IsTextPredictionEnabled)] = MapIsTextPredictionEnabled,
				[nameof(IEntry.MaxLength)] = MapMaxLength,
				[nameof(IEntry.Placeholder)] = MapPlaceholder,
				[nameof(IEntry.PlaceholderColor)] = MapPlaceholderColor,
				[nameof(IEntry.Text)] = MapText,
				[nameof(IEntry.TextColor)] = MapTextColor,
				[nameof(AutoCompleteEntry.TextMemberPath)] = MapTextMemberPath,
				[nameof(AutoCompleteEntry.DisplayMemberPath)] = MapDisplayMemberPath,
				[nameof(AutoCompleteEntry.IsSuggestionListOpen)] = MapIsSuggestionListOpen,
				[nameof(AutoCompleteEntry.UpdateTextOnSelect)] = MapUpdateTextOnSelect,
				[nameof(AutoCompleteEntry.ItemsSource)] = MapItemsSource,
				[nameof(AutoCompleteEntry.SelectedSuggestion)] = MapSelectedSuggestion,
			};

		/// <summary>
		/// Command Mapper dictionary
		/// </summary>
		public static CommandMapper<AutoCompleteEntry, IAutoCompleteEntryHandler> CommandMapper = new(ViewCommandMapper)
		{
		};

		/// <summary>
		/// Create an instance of <see cref="AutoCompleteEntryHandler"/>
		/// </summary>
		public AutoCompleteEntryHandler() : base(Mapper)
		{
		}

        /// <summary>
        /// Create an instance of <see cref="AutoCompleteEntryHandler"/>
        /// </summary>
        /// <param name="mapper"></param>
        public AutoCompleteEntryHandler(IPropertyMapper mapper)
			: base(mapper ?? Mapper, CommandMapper)
		{
		}

        /// <summary>
        /// Create an instance of <see cref="AutoCompleteEntryHandler"/>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="commandMapper"></param>
        public AutoCompleteEntryHandler(IPropertyMapper mapper, CommandMapper commandMapper)
			: base(mapper ?? Mapper, commandMapper ?? CommandMapper)
		{
		}

		AutoCompleteEntry IAutoCompleteEntryHandler.VirtualView => VirtualView;

		PlatformView IAutoCompleteEntryHandler.PlatformView => PlatformView;
	}
}
