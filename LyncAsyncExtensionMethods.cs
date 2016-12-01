using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Conversation.AudioVideo;
using Microsoft.Lync.Model;

// ReSharper disable once CheckNamespace
namespace LyncAsyncExtensionMethods
{
    internal static class ModalityMethods
    {
        public static Task SetMuteAsync(this Participant m, bool mute)
        {
            return Task.Factory.FromAsync(
                m.BeginSetMute,
                m.EndSetMute, mute, null);
        }

        public static Task SendDtmfAsync(this AudioChannel m, string tones)
        {
            return Task.Factory.FromAsync(
                m.BeginSendDtmf,
                m.EndSendDtmf, tones, null);
        }

        public static Task DisconnectAsync(this Modality m, ModalityDisconnectReason reason)
        {
            return Task.Factory.FromAsync(
                m.BeginDisconnect,
                m.EndDisconnect, reason, null);
        }

        public static Task RetrieveAsync(this Modality m)
        {
            return Task.Factory.FromAsync(
                m.BeginRetrieve,
                m.EndRetrieve, null);
        }

        public static Task HoldAsync(this Modality m)
        {
            return Task.Factory.FromAsync(
                m.BeginHold,
                m.EndHold, null);
        }

        public static Task ConnectAsync(this Modality m)
        {
            return Task.Factory.FromAsync(
                m.BeginConnect,
                m.EndConnect, null);
        }

        public class TransferResponse
        {
            public ModalityState TargetState { get; set; }
            public IList<string> ContextProperties { get; set; }
        }

        public static Task<TransferResponse> TransferAsync(this Modality m, ContactEndpoint endpoint, TransferOptions options)
        {
            return Task.Factory.FromAsync(m.BeginTransfer, result =>
            {
                ModalityState state;
                IList<string> prop;
                m.EndTransfer(out state, out prop, result);
                return new TransferResponse { TargetState = state, ContextProperties = prop };

            }, endpoint, options, null);
        }

        public static Task<TransferResponse> ConsultativeTransferAsync(this Modality m, Conversation conversation, TransferOptions options)
        {
            return Task.Factory.FromAsync(m.BeginConsultativeTransfer, result =>
            {
                ModalityState state;
                IList<string> prop;
                m.EndConsultativeTransfer(out state, out prop, result);
                return new TransferResponse { TargetState = state, ContextProperties = prop };

            }, conversation, options, null);
        }
    }
}
