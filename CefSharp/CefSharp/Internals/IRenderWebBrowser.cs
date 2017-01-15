﻿// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;

namespace CefSharp.Internals
{
    public interface IRenderWebBrowser : IWebBrowserInternal
    {
        ScreenInfo GetScreenInfo();
        ViewRect GetViewRect();

        BitmapInfo CreateBitmapInfo(bool isPopup);
        void InvokeRenderAsync(BitmapInfo bitmapInfo);

        void SetCursor(IntPtr cursor, CefCursorType type);

        bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y);
        void UpdateDragCursor(DragOperationsMask operation);

        void SetPopupIsOpen(bool show);
        void SetPopupSizeAndPosition(int width, int height, int x, int y);

        /// <summary>
        /// Called when the IME composition range has changed.
        /// </summary>
        /// <param name="selectedRange">is the range of characters that have been selected</param>
        /// <param name="characterBounds">is the bounds of each character in view coordinates.</param>
        void OnImeCompositionRangeChanged(Range selectedRange, Rect[] characterBounds);
    };
}
