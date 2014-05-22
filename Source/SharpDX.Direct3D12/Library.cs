﻿// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace SharpDX.Direct3D12
{
    public partial class Library
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Library"/> class.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="buffer">The buffer.</param>
        /// <exception cref="System.ArgumentNullException">
        /// device
        /// or
        /// buffer
        /// </exception>
        /// <unmanaged>HRESULT ID3D12Device::CreateLibrary([In, Buffer] const void* pLibraryBlob,[In] SIZE_T BlobLength,[Out, Fast] ID3D12Library** ppLibrary)</unmanaged>
        ///   <unmanaged-short>ID3D12Device::CreateLibrary</unmanaged-short>
        public unsafe Library(Device device, byte[] buffer) : base(IntPtr.Zero)
        {
            if(device == null) throw new ArgumentNullException("device");
            if(buffer == null) throw new ArgumentNullException("buffer");
            fixed(void* ptr = buffer)
            {
                device.CreateLibrary((IntPtr)ptr, buffer.Length, this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Library"/> class.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="buffer">The buffer.</param>
        /// <exception cref="System.ArgumentNullException">
        /// device
        /// or
        /// buffer
        /// </exception>
        public Library(Device device, DataPointer buffer)
            : base(IntPtr.Zero)
        {
            if (device == null) throw new ArgumentNullException("device");
            if (buffer.Pointer == IntPtr.Zero) throw new ArgumentNullException("buffer");
            device.CreateLibrary(buffer.Pointer, buffer.Size, this);
        }
    }
}