using GenericCrud.Config.IOCContainer;
using GenericCrud.Exceptions;
using GenericCrud.Models;
using GenericCrud.Util;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Service
{
    public class SchedulerSRV
    {
        public IScheduler Scheduler { get; set; }
        public SchedulerSRV()
        {
            switch(SysUtils.RetornarAmbienteEnum())
            {
                case AmbienteEnum.Dev:
                    {
                        ServiceName = "JobSchedulerDEV";
                        HostName = "RJ-TI02a-DSK";
                        break;
                    }
                case AmbienteEnum.Homol:
                    {
                        ServiceName = "JobSchedulerHOMOL";
                        HostName = "10.228.5.10";
                        break;
                    }
                case AmbienteEnum.Prod:
                    {
                        ServiceName = "JobSchedulerPROD";
                        HostName = "10.228.5.10";
                        break;
                    }
            }
            
        }
        
        public string ServiceName { get; set; }
        public string HostName { get; set; }

        //public void RegistrarLog(string mensagem)
        //{
        //    if (EventLog != null)
        //    {
        //        EventLog.WriteEntry(mensagem);
        //    }
        //}

        //public void RegistrarLogErro(string mensagem)
        //{
        //    if (EventLog != null)
        //    {
        //        EventLog.WriteEntry(mensagem, EventLogEntryType.Error);
        //    }
        //}

        public async void Start(ICollection<JobSchedulerDTO> jobs)
        {
            try
            {
                NameValueCollection props = new NameValueCollection()
                {

                    {"quartz.serializer.type", "binary" }
                };
                //RegistrarLog("Obtendo a instância do Quartz");
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();
                this.Scheduler = scheduler;
                                
                if (jobs != null && jobs.Count > 0)
                {
                    foreach (var tipo in jobs)
                    {
                        IJobDetail job = tipo.GetJob();
                        var concurrent = job.ConcurrentExecutionDisallowed;
                        ITrigger trigger = tipo.CriarTrigger();
                        job.JobDataMap.Add("lstJobsDTO", jobs);
                        await scheduler.ScheduleJob(job, trigger);
                    }
                }

                await scheduler.Start();
            }
            catch (Exception e)
            {
                string mensagem = ExceptionFormatter.RecursiveFindExceptionsMessage(e);
                //RegistrarLogErro(mensagem);
            }

        }

        public void Stop()
        {
            if(Scheduler != null)
            {
                IOCContainerProxy.StaticDispose();
                Scheduler.Shutdown();
            }
        }

        public void StartService()
        {
            ServiceController serviceController = new ServiceController(ServiceName, HostName);
            serviceController.Start();
            serviceController.Close();
        }

        public void StopService()
        {
            ServiceController serviceController = new ServiceController(ServiceName, HostName);
            serviceController.Stop();
            serviceController.Close();
        }
    }
}
    