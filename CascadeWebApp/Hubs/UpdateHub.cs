using Microsoft.AspNetCore.SignalR;

namespace CascadeWebApp.Hubs
{
    public class UpdateHub : Hub
    {
        /// <summary>
        /// Send update notification to all clients
        /// </summary>
        /// <param name="message">The update message</param>
        public async Task SendUpdateToAll(string message)
        {
            await Clients.All.SendAsync("ReceiveUpdate", message);
        }

        /// <summary>
        /// Send update notification to specific group
        /// </summary>
        /// <param name="groupName">The group to send to</param>
        /// <param name="message">The update message</param>
        public async Task SendUpdateToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveUpdate", message);
        }

        /// <summary>
        /// Join a specific group (e.g., "Orders", "Batches", "Items")
        /// </summary>
        /// <param name="groupName">The group name to join</param>
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// Leave a specific group
        /// </summary>
        /// <param name="groupName">The group name to leave</param>
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// Send item update notification
        /// </summary>
        /// <param name="itemId">The item ID that was updated</param>
        /// <param name="action">The action performed (Created, Updated, Deleted)</param>
        public async Task SendItemUpdate(int itemId, string action)
        {
            await Clients.Group("Items").SendAsync("ReceiveItemUpdate", itemId, action);
        }

        /// <summary>
        /// Send order update notification
        /// </summary>
        /// <param name="orderId">The order ID that was updated</param>
        /// <param name="action">The action performed (Created, Updated, Deleted)</param>
        public async Task SendOrderUpdate(int orderId, string action)
        {
            await Clients.Group("Orders").SendAsync("ReceiveOrderUpdate", orderId, action);
        }

        /// <summary>
        /// Send batch update notification
        /// </summary>
        /// <param name="batchId">The batch ID that was updated</param>
        /// <param name="action">The action performed (Created, Updated, Deleted)</param>
        public async Task SendBatchUpdate(int batchId, string action)
        {
            await Clients.Group("Batches").SendAsync("ReceiveBatchUpdate", batchId, action);
        }

        /// <summary>
        /// Send customer update notification
        /// </summary>
        /// <param name="customerId">The customer ID that was updated</param>
        /// <param name="action">The action performed (Created, Updated, Deleted)</param>
        public async Task SendCustomerUpdate(int customerId, string action)
        {
            await Clients.Group("Customers").SendAsync("ReceiveCustomerUpdate", customerId, action);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}