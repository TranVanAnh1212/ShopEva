/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	 config.language = 'en';
	 config.uiColor = '#AADC6E';

	config.toolbarGroups = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
		{ name: 'forms', groups: ['forms'] },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
		{ name: 'links', groups: ['links'] },
		{ name: 'insert', groups: ['insert'] },
		'/',
		{ name: 'styles', groups: ['styles'] },
		{ name: 'colors', groups: ['colors'] },
		{ name: 'tools', groups: ['tools'] },
		{ name: 'others', groups: ['others'] },
		{ name: 'about', groups: ['about'] }
	];

	config.removeButtons = 'Save,Print,About,Subscript,Superscript,Strike,CopyFormatting,RemoveFormat,CreateDiv,BidiLtr,BidiRtl,Language,Font,FontSize,Format,Styles,TextColor,BGColor,ShowBlocks,Maximize,SelectAll,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Smiley,SpecialChar,Iframe,Preview,ExportPdf';

	config.filebrowserBrowseUrl = '/lib/ckfinder_aspnet_2.6.2.1/CKFinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/lib/ckfinder_aspnet_2.6.2.1/CKFinder/ckfinder.html?type=Images';
	config.filebrowserUploadUrl = '/lib/ckfinder_aspnet_2.6.2.1/CKFinder/connector?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/lib/ckfinder_aspnet_2.6.2.1/CKFinder/connector?command=QuickUpload&type=Images';
	config.filebrowserWindowWidth = '1000';
	config.filebrowserWindowHeight = '700';
};
